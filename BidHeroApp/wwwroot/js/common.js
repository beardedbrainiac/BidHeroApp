// not working
//const container = document.getElementById("toggleConfirmation");
//const modal = new bootstrap.Modal(container);

function ShowToggleConfirmationModal() {
    $('#toggleConfirmation').modal('show');

    // working
    //var toggleConfirmationModal = new bootstrap.Modal(document.getElementById('toggleConfirmation'));
    //toggleConfirmationModal.show();

    // not working
    //this.modal.show();
}

function HideToggleConfirmationModal() {
    $('#toggleConfirmation').modal('hide');

    // not working
    //var toggleConfirmationModal = new bootstrap.Modal(document.getElementById('toggleConfirmation'));
    //toggleConfirmationModal.hide();

    // not working
    //this.modal.hide();

    // working
    //document.getElementById('toggleConfirmationClose').click();
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmation').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmation').modal('hide');
}

function ShowAddCategoryModal() {
    $('#addCategory').modal('show');
}

function HideAddCategoryModal() {
    $('#addCategory').modal('hide');
}

function ShowUpdateCategoryModal() {
    $('#updateCategory').modal('show');
}

function HideUpdateCategoryModal() {
    $('#updateCategory').modal('hide');
}