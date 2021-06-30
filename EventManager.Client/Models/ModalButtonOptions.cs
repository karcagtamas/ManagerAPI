namespace EventManager.Client.Models
{
    /// <summary>
    /// Modal Button options
    /// </summary>
    public class ModalButtonOptions
    {
        /// <summary>
        /// Show cancel button
        /// </summary>
        public bool ShowCancelButton { get; set; } = true;

        /// <summary>
        /// Show confirm button
        /// </summary>
        public bool ShowConfirmButton { get; set; } = false;

        /// <summary>
        /// Cancel button type
        /// </summary>
        public CancelButton CancelButtonType { get; set; } = CancelButton.Cancel;

        /// <summary>
        /// Confirm button type
        /// </summary>
        public ConfirmButton ConfirmButtonType { get; set; } = ConfirmButton.Ok;

        /// <summary>
        /// Init button options
        /// </summary>
        public ModalButtonOptions() { }

        /// <summary>
        /// Init button options
        /// </summary>
        /// <param name="showCancel">Show cancel button</param>
        /// <param name="showConfirm">Show conform button</param>
        public ModalButtonOptions(bool showCancel, bool showConfirm)
        {
            this.ShowCancelButton = showCancel;
            this.ShowConfirmButton = showConfirm;
        }

        /// <summary>
        /// Init button options
        /// </summary>
        /// <param name="showCancel">Show cancel button</param>
        /// <param name="showConfirm">Show conform button</param>
        /// <param name="cancelButton">Cancel button type</param>
        /// <param name="confirmButton">Confirm button type</param>
        public ModalButtonOptions(bool showCancel, bool showConfirm, CancelButton cancelButton, ConfirmButton confirmButton)
        {
            this.ShowCancelButton = showCancel;
            this.ShowConfirmButton = showConfirm;
            this.CancelButtonType = cancelButton;
            this.ConfirmButtonType = confirmButton;
        }
    }
}
