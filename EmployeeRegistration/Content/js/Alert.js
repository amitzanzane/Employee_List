function displayAlert(titleName,message, type, controlName) {
    //$.alert.open({
    //    content: message, icon: type, title: ClientName,
    //    callback: function () {
    //        $(controlName).focus();
    //    }
    //});

    swal({
        title: titleName,
        text: message,
        type: type
    }).then(function () {
        $(controlName).focus();
    });

}

function displayMessage(message, type) {
    //$.alert.open({
    //    content: message, icon: type, title: ClientName
    //});

    swal({
        title: titleName,
        text: message,
        type: type
    });
}
