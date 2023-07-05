using ArtistHomepage.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArtistHomepage.Models
{
    public class ArtworkDraft : IArtworkDraft
    {
        private readonly ApplicationDbContext context;

        public string? ArtworkDraftId { get; set; }

        public ArtworkDraftContent? ArtworkDraftContent { get; set; }

        public IdentityUser Artist { get; set; }

        private ArtworkDraft(ApplicationDbContext context)
        {
            this.context = context;
        }

        public static ArtworkDraft GetArtworkDraft(IServiceProvider services)
        {
            var task = GetArtworkDraftAsync(services);
            task.Wait();
            return task.Result;
        }

        public static async Task<ArtworkDraft> GetArtworkDraftAsync(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext?.Session;

            ApplicationDbContext context = services.GetService<ApplicationDbContext>()
                ?? throw new Exception("Failed to get ApplicationDbContext");

            string artworkDraftId = session?.GetString("ArtworkDraftId") ?? Guid.NewGuid().ToString();
            session?.SetString("ArtworkDraftId", artworkDraftId);

            var draft = new ArtworkDraft(context) { ArtworkDraftId = artworkDraftId };

            UserManager<IdentityUser> userManager = services.GetService<UserManager<IdentityUser>>()
                ?? throw new Exception("Failed to get UserManager");

            var user = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext?.User.Identity;

            draft.Artist = await userManager.FindByNameAsync(user.Name);
            if (draft.Artist == null)
            {
                throw new Exception("Failed to assign User to ArtworkDraft");
            }

            return draft;
        }

        public void AddImageToDraft(Image image)
        {
            var artworkDraftImage = this.GetArtworkDraftContent()?.Images.SingleOrDefault(i => i.Id == image.Id);

            if (artworkDraftImage == null)
            {
                this.ArtworkDraftContent!.Images.Add(image);
                this.context.ArtworkDraftContents.Update(this.ArtworkDraftContent);
            }

            this.context.SaveChanges();
        }

        public void ClearDraft()
        {
            this.ArtworkDraftContent = new ArtworkDraftContent()
            {
                Artist = this.Artist,
                ArtistId = this.Artist.Id,
                ArtworkDraftId = this.ArtworkDraftId,
            };

            this.context.ArtworkDraftContents.Update(this.ArtworkDraftContent);
            this.context.SaveChanges();
        }

        public ArtworkDraftContent? GetArtworkDraftContent()
        {
            return this.ArtworkDraftContent ??= this.context.ArtworkDraftContents
                .Include(c => c.Images)
                .SingleOrDefault(c => c.ArtworkDraftId == this.ArtworkDraftId);
        }

        public int RemoveImageFromDraft(Image image)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
