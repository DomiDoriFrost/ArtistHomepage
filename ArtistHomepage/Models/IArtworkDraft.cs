namespace ArtistHomepage.Models
{
    public interface IArtworkDraft
    {
        void AddImageToDraft(Image image);

        int RemoveImageFromDraft(Image image);

        ArtworkDraftContent? GetArtworkDraftContent();

        ArtworkDraftContent? ArtworkDraftContent { get; set; }

        void Save();

        void ClearDraft();
    }
}
