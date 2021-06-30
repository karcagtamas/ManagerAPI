namespace EventManager.Client.Models
{
    /// <summary>
    /// Modal options
    /// </summary>
    public class ModalOptions
    {
        /// <summary>
        /// Position
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Style
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// Disable background cancel
        /// </summary>
        public bool? DisableBackgroundCancel { get; set; }

        /// <summary>
        /// Hide button
        /// </summary>
        public bool? HideButton { get; set; }

        /// <summary>
        /// Hide close button
        /// </summary>
        public bool? HideCloseButton { get; set; }

        /// <summary>
        /// Hide header
        /// </summary>
        public bool? HideHeader { get; set; }

        /// <summary>
        /// Button options
        /// </summary>
        public ModalButtonOptions ButtonOptions { get; set; }

        /// <summary>
        /// Init modal options
        /// </summary>
        public ModalOptions()
        {
            this.ButtonOptions = new ModalButtonOptions();
        }

        /// <summary>
        /// Init modal options with button options
        /// </summary>
        /// <param name="options">Button options</param>
        public ModalOptions(ModalButtonOptions options)
        {
            this.ButtonOptions = options == null ? new ModalButtonOptions() : options;
        }

    }

    /// <summary>
    /// Cancel button type
    /// </summary>
    public enum CancelButton
    {
        /// <summary>
        /// Cancel
        /// </summary>
        Cancel,

        /// <summary>
        /// Close
        /// </summary>
        Close
    }

    /// <summary>
    /// Confirm button type
    /// </summary>
    public enum ConfirmButton
    {
        /// <summary>
        /// Confirm
        /// </summary>
        Confirm,

        /// <summary>
        /// Save
        /// </summary>
        Save,

        /// <summary>
        /// Ok
        /// </summary>
        Ok
    }
}