function ShowToggleConfirmationModal() {
    var toggleConfirmationModal = new bootstrap.Modal(document.getElementById('toggleConfirmation'));
    toggleConfirmationModal.show();
}

function HideToggleConfirmationModal() {
    document.getElementById('toggleConfirmationClose').click();
}