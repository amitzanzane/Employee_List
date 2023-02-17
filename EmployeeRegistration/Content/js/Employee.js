
function selectEmployeeList() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Employee/BindEmployeeList",
        data: '{}',
        dataType: "json",
        success: function (data) {

            $("#tblEmployeeList").html("<thead ><tr><th>Email</th><th>Country</th><th>State</th><th>City</th><th>Pan No</th><th>Passport No</th></tr></thead><tbody></tbody>");
            for (var i = 0; i < data.length; i++) {
                var strRow = [];
                //var color = 'black';
                //var checked = 'checked';
                //if (data[i].IsActive == 0) {
                //    color = 'red';
                //    checked = '';
                //}

                strRow.push('<tr>');
                strRow.push(String.format("<td> {0} </td>", data[i].emailAddress));
                strRow.push(String.format("<td> {0} </td>", data[i].country));
                strRow.push(String.format("<td> {0} </td>", data[i].state));
                strRow.push(String.format("<td> {0} </td>", data[i].city));
                strRow.push(String.format("<td> {0} </td>", data[i].panNumber));
                strRow.push(String.format("<td> {0} </td>", data[i].passportNumber));
                //strRow.push(String.format("<td class='text-right'> {0} </td>", data[i].Price.toFixed(2)));
                //strRow.push(String.format("<td class='text-center'> <input type='checkbox' onchange=UpdateFlag({0},{1}) id='chkAct{0}' {2}></td>", i, data[i].MenuDetailID, checked));
                //strRow.push(String.format("<td class='GrCenter'> <img src='/Content/AdminTemplate/images/edit.png' title='Edit' onclick=\"editMenuDetail({0},{1},{2})\"> </td>", data[i].MenuDetailID, data[i].HotelID, data[i].MenuID));

                strRow.push('</tr>');
                $("#tblEmployeeList").append(strRow.join(""));
            }
            $('#tblEmployeeList').DataTable({
                "bDestroy": true
            });
            jQuery('.dataTable').wrap('<div class="dataTables_scroll" />');
        },
    });
}

var table;

$(document).ready(function () {
    BindCountryDropdown();
    $("#ddlState").chosen();
    $("#ddlCity").chosen();
    BindDataTable();
});

var BindDataTable = function () {
    table = $("#tblEmployeeList").DataTable(
        {
            "ajax": {
                "url": "/Employee/BindEmployeeList",
                "type": "GET",
                "datatype": "json"
            },
            "columns": [
                { "data": "emailAddress" },
                { "data": "country" },
                { "data": "state" },
                { "data": "city" },
                { "data": "panNumber" },
                { "data": "passportNumber" },
                {
                    "data": "gender",
                    "render": function (gender) {
                        if (gender == 1) {
                            return 'Male'
                        }
                        return 'Female'
                    }
                },
                {
                    "data": "isActive",
                    "render": function (isActive) {
                        if (isActive == 1) {
                            return 'Yes'
                        }
                        return 'No'
                    }
                },
                {
                    "data": "profileImage",
                    "render": function (profileImage) {
                        if (profileImage == "") {
                            return '<img src="/Uploads/Employee/user.jpg" height="60">'
                        }
                        return '<img src="/' + profileImage + '" height="60">'
                    }
                },
                {
                    "data": "row_Id",
                    "render": function (row_Id, type, full, meta) {
                        return "<a class='text-center' href='#' onclick='OpenEditModal(\"" + row_Id + "\",\"" + full.firstName + "\",\"" + full.employeeCode + "\",\"" + full.lastName + "\",\"" + full.emailAddress + "\",\"" + full.mobileNumber + "\",\"" + full.panNumber + "\",\"" + full.passportNumber + "\",\"" + full.dateOfBirth + "\",\"" + full.dateOfJoinee + "\",\"" + full.countryId + "\",\"" + full.stateId + "\",\"" + full.cityId + "\",\"" + full.profileImage + "\",\"" + full.gender + "\",\"" + full.isActive + "\")'><img src='/Content/images/edit.png' width='30' height='30'></a>"

                    }
                },
                {
                    "data": "row_Id",
                    "render": function (row_Id, type, full, meta) {
                        return "<a class='text-center' href='#' onclick='DeleteEmployee(\"" + row_Id + "\")'><img src='/Content/images/delete.png' width='30' height='30'></a></a>"
                    }
                }
            ]
        });
    //selectEmployeeList();
}

var OpenEditModal = function (row_Id, firstName, employeeCode, lastName, emailAddress, mobileNumber, panNumber, passportNumber, dob, doj, countryId, stateId, cityId, profileImage, gender, isActive) {
    $("#btnAddEdit").text("Update");

    $("#txtEmployeeCode").show();
    $("#lblEmployeeCode").show();
    $("#txtDOB").datepicker({
        dateFormat: 'dd/mm/yy'
    });
    $("#txtDOJ").datepicker({
        dateFormat: 'dd/mm/yy'
    });
    $("#hdnRow_Id").val(row_Id);
    $("#txtEmployeeCode").val(employeeCode);
    $("#txtFirstName").val(firstName);
    $("#txtLastName").val(lastName);
    $("#txtEmailAddress").val(emailAddress);
    $("#txtMobileNumber").val(mobileNumber);
    $("#txtPanNumber").val(panNumber);
    $("#txtPassportNumber").val(passportNumber);
    var birthdate = moment(dob, 'DD-MM-yyyy hh:mm:ss').format('DD/MM/yyyy');
    $("#txtDOB").datepicker("setDate", birthdate);
    var joindate = moment(doj, 'DD-MM-yyyy hh:mm:ss').format('DD/MM/yyyy');
    $("#txtDOJ").datepicker("setDate", joindate);
    $("input[name='gender'][value='" + gender + "']").prop('checked', true);
    if (isActive == 1) {
        $('#chkIsActive').prop('checked', true);
    }
    else {
        $('#chkIsActive').prop('checked', false);
    }
    $('#ddlCountry').val(countryId).trigger("chosen:updated");
    $.when(BindStateDropdown()).then
        (
            function () {
                $('#ddlState').val(stateId).trigger("chosen:updated");
                $.when(BindCityDropdown()).then
                    (
                        function () {
                            $('#ddlCity').val(cityId).trigger("chosen:updated");
                        }
                    );
            }
        );
    $('#addEditEmployee').modal('show');
}

var OpenAddModal = function () {
    $('#addEditEmployee').modal('show');
    ClearModalValues();

    $("#btnAddEdit").text("Save");
    $("#txtDOB").datepicker({
        dateFormat: 'dd/mm/yy'
    });
    $("#txtDOJ").datepicker({
        dateFormat: 'dd/mm/yy'
    });
    $("#txtEmployeeCode").hide();
    $("#lblEmployeeCode").hide();
}

var ClearCityDropdown = function () {
    $("#ddlCity").empty();
    $('#ddlCity').trigger("chosen:updated");
}

var ClearModalValues = function () {
    $("#hdnRow_Id").val("");
    $("#txtEmployeeCode").val("");
    $("#txtFirstName").val("");
    $("#txtLastName").val("");
    $("#txtEmailAddress").val("");
    $("#txtMobileNumber").val("");
    $("#txtPanNumber").val("");
    $("#txtPassportNumber").val("");
    $("#txtDOB").val("");
    $("#txtDOJ").val("");
    $("#ddlCountry").val("0");
    $('#ddlCountry').trigger("chosen:updated");
    $("#ddlState").empty();
    $('#ddlState').trigger("chosen:updated");
    $("#ddlCity").empty();
    $('#ddlCity').trigger("chosen:updated");
    $("#profileUpload").val("");
    $('#chkIsActive').prop('checked', false);
    $('input[name="gender"]').prop('checked', false);
    $("#lblEmailID").html("");
    $("#lblMobile").html("");
    $("#lblPan").html("");
    $("#lblPassport").html("");
}

var AddEditEmployee = function () {
    var row_Id = $("#hdnRow_Id").val();
    var firstName = $("#txtFirstName").val();
    var lastName = $("#txtLastName").val();
    var email = $("#txtEmailAddress").val();
    var mobile = $("#txtMobileNumber").val();
    var pan = $("#txtPanNumber").val();
    var passport = $("#txtPassportNumber").val();
    var dob = $("#txtDOB").val();
    var doj = $("#txtDOJ").val();
    var countryId = $("#ddlCountry").val();
    var stateId = $("#ddlState").val();
    var cityId = $("#ddlCity").val();

    var gender = $("input[name='gender']:checked").val();
    var isActive = 0;
    if ($("#chkIsActive").prop('checked') == true) {
        isActive = 1;
    }

    if (!isValidString(firstName)) {
        displayAlert('Employee Registration', 'Please enter first name.', 'warning', "#txtFirstName");
        return false;
    }
    if (!EmailValidation(email)) {
        displayAlert('Employee Registration', 'Please enter valid email.', 'warning', "#txtEmailAddress");
        return false;
    }
    if (!isValidString(mobile)) {
        displayAlert('Employee Registration', 'Please enter mobile number.', 'warning', "#txtMobileNumber");
        return false;
    }
    if (!isValidString(pan)) {
        displayAlert('Employee Registration', 'Please enter pan number.', 'warning', "#txtPanNumber");
        return false;
    }
    if (!isValidString(passport)) {
        displayAlert('Employee Registration', 'Please enter passport number.', 'warning', "#txtPassportNumber");
        return false;
    }
    if (!isValidString(dob)) {
        displayAlert('Employee Registration', 'Please enter date of birth.', 'warning', "#txtDOB");
        return false;
    }
    if (!isValidDdl(countryId)) {
        displayAlert('Employee Registration', 'Please select country.', 'warning', "#ddlCountry");
        return false;
    }
    if (!isValidDdl(stateId)) {
        displayAlert('Employee Registration', 'Please select state.', 'warning', "#ddlState");
        return false;
    }
    if (!isValidDdl(cityId)) {
        displayAlert('Employee Registration', 'Please select city.', 'warning', "#ddlCity");
        return false;
    }
    if ($('input[name="gender"]:checked').length == 0) {
        displayAlert('Employee Registration', 'Please select gender.', 'warning', "#male");
        return false;
    }

    var profileUpload = $("#profileUpload").get(0).files;
    var data = new FormData();
    data.append('row_Id', row_Id);
    data.append('firstName', firstName);
    data.append('lastName', lastName);
    data.append('countryId', countryId);
    data.append('stateId', stateId);
    data.append('cityId', cityId);
    data.append('emailAddress', email);
    data.append('mobileNumber', mobile);
    data.append('panNumber', pan);
    data.append('passportNumber', passport);
    data.append('gender', gender);
    data.append('isActive', isActive);
    data.append('dateOfBirth', dob);
    data.append('dateOfJoinee', doj);
    data.append('ImageFile', profileUpload[0]);

    swal({
        title: "Are you sure?",
        text: "This action can not be revert!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: '#DD6B55',
        confirmButtonText: 'Yes, I am sure!',
        cancelButtonText: "No, cancel it!",
        closeOnConfirm: false,
        closeOnCancel: true
    },
        function (isConfirm) {

            if (isConfirm) {

                $.ajax({
                    type: "POST",
                    url: "/Employee/InsertUpdateEmployee",
                    data: data,
                    contentType: false,
                    processData: false,
                    success: function (result) {
                        if (result != '') {

                            swal({
                                title: "Employee Registration",
                                text: "Employee inserted or updated successfully!",
                                type: "success"
                            }, function () {
                                table.ajax.reload();
                                $('#addEditEmployee').modal('hide');
                            });
                        }
                        ClearModalValues();
                    },
                    error: function (result) {
                        swal("Employee not inserted or updated");
                    }
                });
            } else {
                $('#addEditEmployee').modal('hide');
                //location.reload();
                ClearModalValues();
            }
        });
}

var BindCountryDropdown = function () {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/Employee/GetAllCountries",
        data: '{}',
        dataType: "json",

        success: function (response) {

            $("#ddlCountry").empty();
            $("#ddlCountry").append('<option value=0> --Select-- </option>');
            for (var i = 0; i < response.data.length; i++) {
                var strRow = [];
                strRow.push(String.format("<option value='{0}'> {1} </option>", response.data[i].countryId, response.data[i].countryName));
                $("#ddlCountry").append(strRow);
            }
            $('#ddlCountry').trigger("chosen:updated");
            $("#ddlCountry").chosen();
        },
        error: function (result) {
            //displayMessage(String.format(notfound), 'error');
        }
    });
}

var BindStateDropdown = async function () {
    var dfd = $.Deferred();
    var countryId = $("#ddlCountry").val();

    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/Employee/GetAllStatesByCountryId?countryId=" + countryId,
        data: '{}',
        dataType: "json",

        success: function (response) {

            $("#ddlState").empty();
            $("#ddlState").append('<option value=0> --Select-- </option>');
            for (var i = 0; i < response.data.length; i++) {
                var strRow = [];
                strRow.push(String.format("<option value='{0}'> {1} </option>", response.data[i].stateId, response.data[i].stateName));
                $("#ddlState").append(strRow);
            }
            $('#ddlState').trigger("chosen:updated");
        },
        error: function (result) {
            //displayMessage(String.format(notfound), 'error');
        }
    });
    dfd.resolve();
    return dfd.promise();
}

var BindCityDropdown = async function () {
    var dfd = $.Deferred();
    var stateId = $("#ddlState").val();

    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/Employee/GetAllCitiesByStateId?stateId=" + stateId,
        data: '{}',
        dataType: "json",

        success: function (response) {

            $("#ddlCity").empty();
            $("#ddlCity").append('<option value=0> --Select-- </option>');
            for (var i = 0; i < response.data.length; i++) {
                var strRow = [];
                strRow.push(String.format("<option value='{0}'> {1} </option>", response.data[i].cityId, response.data[i].cityName));
                $("#ddlCity").append(strRow);
            }
            //$("#ddlState").chosen();
            $('#ddlCity').trigger("chosen:updated");
        },
        error: function (result) {
            //displayMessage(String.format(notfound), 'error');
        }
    });
    dfd.resolve();
    return dfd.promise();
}

var DeleteEmployee = function (row_Id) {

    var jsonObj = {
        employeeRowID: row_Id
    };
    var jData = JSON.stringify(jsonObj)

    swal({
        title: "Are you sure?",
        text: "This action can not be revert!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: '#DD6B55',
        confirmButtonText: 'Yes, I am sure!',
        cancelButtonText: "No, cancel it!",
        closeOnConfirm: false,
        closeOnCancel: true
    },
        function (isConfirm) {

            if (isConfirm) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/Employee/DeleteEmployee",
                    data: jData,

                    success: function (data) {
                        swal({
                            title: "Employee Registration",
                            text: data,
                            type: "success"
                        }, function () {
                            table.ajax.reload();
                        });
                    },
                    error: function (result) {
                        swal("Employee not deleted");
                    }
                });
            } else {

            }
        });
}

function uniqueValidation(id) {
    var fieldValue = $('#' + id).val();
    if (fieldValue == "") {
        return false;
    }

    var fieldName = "";
    if (id == "txtEmailAddress") {
        fieldName = "email";
    }
    else if (id == "txtMobileNumber") {
        fieldName = "mobile";
    }
    else if (id == "txtPanNumber") {
        fieldName = "pan";
    }
    else if (id == "txtPassportNumber") {
        fieldName = "passport";
    }

    var jsonObj = {
        fieldName: fieldName,
        fieldValue: fieldValue
    };
    var jsonData = JSON.stringify(jsonObj)
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Employee/UniqueFieldvalidation",
        data: jsonData,
        success: function (data) {
            if (fieldName == "email") {
                if (data != "") {
                    $("#lblEmailID").html("Email already exist");
                    $("#lblEmailID").css('color', 'red');
                }
                else {
                    $("#lblEmailID").html("Email is Available");
                    $("#lblEmailID").css('color', 'green');
                }
            }
            else if (fieldName == "mobile") {
                if (data != "") {
                    $("#lblMobile").html("Mobile number already exist");
                    $("#lblMobile").css('color', 'red');
                }
                else {
                    $("#lblMobile").html("Mobile number is Available");
                    $("#lblMobile").css('color', 'green');
                }
            }
            else if (fieldName == "pan") {
                if (data != "") {
                    $("#lblPan").html("Pan number already exist");
                    $("#lblPan").css('color', 'red');
                }
                else {
                    $("#lblPan").html("Pan number is Available");
                    $("#lblPan").css('color', 'green');
                }
            }
            else if (fieldName == "passport") {
                if (data != "") {
                    $("#lblPassport").html("Passport number already exist");
                    $("#lblPassport").css('color', 'red');
                }
                else {
                    $("#lblPassport").html("Passport number is Available");
                    $("#lblPassport").css('color', 'green');
                }
            }
        },
        error: function (result) {
        }
    });
}
