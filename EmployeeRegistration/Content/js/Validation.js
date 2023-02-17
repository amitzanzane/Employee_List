function isValidDdl(value) {

    if (value == "0" || value == null)
        return false;

    if (value == undefined)
        return false;

    return true;
}

function isValidString(value)
{
    if (value == "" || value == null)
        return false;

    if (value == undefined)
        return false;

    return true;
}

function isAmountNumber(e, id) {

    $('#' + id).on("input", function () {
        var dInput = this.value;
        if (isNaN(dInput) || dInput <= 0) {
            $("#" + id).val('');
        }
    });

    var r = e.which ? e.which : e.keyCode;
    return r > 31 && (48 > r || r > 57) && (e.which != 46 || $(this).val().indexOf('.') != -1) ? !1 : void 0
}

function isNumber(event) {
    return (event.charCode == 8 || event.charCode == 0 || event.charCode == 13) ? null : event.charCode >= 48 && event.charCode <= 57;
}


function isPercent(e, id) {

    $('#' + id).on("input", function () {
        var dInput = this.value;
        if (isNaN(dInput)) {
            $("#" + id).val('');
        }
    });

    var r = e.which ? e.which : event.keyCode;
    return r > 31 && (48 > r || r > 57) && (e.which != 46 || $(this).val().indexOf('.') != -1) ? !1 : void 0
}

function EmailValidation(email) {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false;
    } else {
        return true;
    }
}

function isPANKey(e, controlName) {
    var r = e.which ? e.which : e.keyCode;
    if ($("#" + controlName).val().length < 5 || $("#" + controlName).val().length > 8) {
        return (64 > r || r > 91) && (96 > r || r > 122) && (e.which != 8) ? !1 : void 0
    }
    else {
        return r > 31 && (48 > r || r > 57) && (e.which != 46) && (e.which != 8) ? !1 : void 0
    }
}

function isGSTKey(e, controlName) {
    var r = e.which ? e.which : e.keyCode;
    console.log("length:" + $("#" + controlName).val().length);
    var contentLength = $("#" + controlName).val().length;

    if (contentLength <= 1) {
        //number
        return r > 31 && (48 > r || r > 57) && (e.which != 46) && (e.which != 8) ? !1 : void 0
    }
    else if (contentLength >= 2 && contentLength <= 6) {
        //alphanumberic
        return (64 > r || r > 91) && (96 > r || r > 122) && (e.which != 8) ? !1 : void 0
    }
    else if (contentLength >= 7 && contentLength <= 10) {
        return r > 31 && (48 > r || r > 57) && (e.which != 46) && (e.which != 8) ? !1 : void 0
    }
    else if (contentLength == 11) {
        return (64 > r || r > 91) && (96 > r || r > 122) && (e.which != 8) ? !1 : void 0
    }
    else if (contentLength == 12) {
        return r > 31 && (48 > r || r > 57) && (e.which != 46) && (e.which != 8) ? !1 : void 0
    }
    else if (contentLength == 13) {
        return (64 > r || r > 91) && (96 > r || r > 122) && (e.which != 8) ? !1 : void 0
    }
    else if (contentLength == 14) {
        return (48 > r || r > 57) && (64 > r || r > 91) && (96 > r || r > 122) && (e.which != 8) ? !1 : void 0
    }
    else {

        return (64 > r || r > 91) && (96 > r || r > 122) && (e.which != 8) ? !1 : void 0
    }
}

function isLetter(e,id) {
    $('#' + id).on("input", function () {
        var dInput = this.value;
        if (!isNaN(dInput)) {
            $("#" + id).val('');
        }
    });

    var r = e.which ? e.which : e.keyCode;
    return  !(91 > r && r > 64) && !(123 > r && r > 96) && (r!=32 && r!=8)  ? !1 : void 0
}