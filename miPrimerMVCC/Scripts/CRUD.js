function showhideBtn() {
    $('#btnUpdate').hide();
    $('#btnSave').show();
}
function clearData() {
    $('#id').val("");
    $('#nombre').val("");
    $('#apellidoP').val("");
    $('#apellidoM').val("");
    $('#edad').val("");
}
function validate() {
    var isValid = true;
    if ($('#nombre').val().trim() == "") {
        $('#nombre').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#nombre').css('border-color', 'lightgrey');
    }
    if ($('#apellidoP').val().trim() == "") {
        $('#apellidoP').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#apellidoP').css('border-color', 'lightgrey');
    }
    if ($('#apellidoM').val().trim() == "") {
        $('#apellidoM').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#apellidoM').css('border-color', 'lightgrey');
    }
    if ($('#edad').val().trim() == "") {
        $('#edad').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#edad').css('border-color', 'lightgrey');
    }
    if ($('#sexo').val().trim() == "") {
        $('#sexo').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#sexo').css('border-color', 'lightgrey');
    }
    return isValid;
}

function LoadData() {
    $(function () {
    $("#tblPersons tbody tr").remove();
    $.ajax({
        type: "POST",
        url: '@Url.Action("getPersons")',
        dataType: 'json',
        data: { id: '' },
        success: function (data) {
            var item = "";
            $.each(data, function (i, item) {
                var rows = "<tr>"
                    + "<td id='cell1'>" + item.id + "</td>"
                    + "<td id='cell2'>" + item.nombres + "</td>"
                    + "<td id='cell3'>" + item.apellidop + "</td>"
                    + "<td id='cell4'>" + item.apellidom + "</td>"
                    + "<td id='cell5'>" + item.edad + "</td>"
                    + "<td id='cell6'>" + item.sexo + "</td>"
                    + "<td><button class='btn btn-success' onclick='getbyID(" + item.id + ")'>Edit</button> <button class='btn btn-danger' onclick='Delete(" + item.id + ")'> Delete</button</td>"
                    + "</tr>";
                $('#tblPersons tbody').append(rows)
            });
        },
        error: function (eUrl) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
        }
    });
}
function getbyID(ID) {
    $('#nombre').css('border-color', 'lightgrey');
    $('#apellidoP').css('border-color', 'lightgrey');
    $('#apellidoM').css('border-color', 'lightgrey');
    $('#edad').css('border-color', 'lightgrey');
    $.ajax({
        url: '@Url.Action("getID","Home")' + "/" + ID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#idp').val(result.id);
            $('#nombre').val(result.nombres);
            $('#apellidoP').val(result.apellidop);
            $('#apellidoM').val(result.apellidom);
            $('#edad').val(result.edad);
            $('#sexo').val(result.sexo);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnSave').hide();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function Delete(id) {
    var ans = confirm("¿ Seguro que desea eliminar el registro?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: '@Url.Action("deletePerson","Home")' + "/" + id,
            dataType: "json",
            contentType: "applicaton/json; charset=utf-8",
            success: function () {
                DevExpress.ui.notify("Item deleted", "success")
                LoadData();
            },
            error: function () {
                DevExpress.ui.notify("Error", "error");
            }
        });
    }

}
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var IDP = $('#idp').val();
    var per = {};
    per.nombres = $("#nombre").val();
    per.apellidop = $("#apellidoP").val();
    per.apellidom = $("#apellidoM").val();
    per.edad = $("#edad").val();
    per.sexo = $("#sexo").val();
    $.ajax({
        type: "POST",
        url: '@Url.Action("updatePerson","Home")' + "/" + IDP,
        dataType: 'json',
        contentType: "application/json; charset=utf8",
        data: JSON.stringify(per),
        success: function () {
            clearData();
            LoadData();
            DevExpress.ui.notify("User updated", "success");
        },
        error: function () {
            DevExpress.ui.notify("Error", "error");
        }
    })
}

$(function () {
    LoadData();

    $("#btnSave").click(function () {
        var res = validate();
        if (res == false) {
            return false;
        }
        var std = {};
        std.nombres = $("#nombre").val();
        std.apellidop = $("#apellidoP").val();
        std.apellidom = $("#apellidoM").val();
        std.edad = $("#edad").val();
        std.sexo = $("#sexo").val();

        $.ajax({
            type: "POST",
            url: '@Url.Action("createPerson")',
            dataType: "json",
            data: JSON.stringify(std),
            contentType: "application/json;",
            success: function () {
                DevExpress.ui.notify("User has been added succesfully", "success");
                LoadData();
                $('#myModal').modal('hide');
                clearData();
            },
            error: function () {
                DevExpress.ui.notify("Error while inserting data", "error");
                LoadData();
            }
        });

        return false;
    });
});