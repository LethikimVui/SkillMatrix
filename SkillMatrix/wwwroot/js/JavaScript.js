


$('body').off('click', '.update').on('click', '.update', Update);
$('body').off('click', '#btn-save').on('click', '#btn-save', Save);

function Update() {

    var tranferSAP = $(this).data('sap');
    debugger
    $.ajax({
        type: 'post',
        url: '/Admin/GetBySAP',
        dataType: 'json',
        data: { sap: tranferSAP }, /*sap la input cua ham /Employee/GetById*/
        success: function (response) {
            var data = response.result;
            //$('#txt-sap').val(tranferSAP);

            $('#txt-image').val(data.Image);

        }
    })
}

function Save() {
    if ($('#frm-save').valid()) {
        var model = new Object();
        model.Image = $('#txt-image').val();
        model.SAP = $('#txt-sap').val();
        debugger
        $.ajax({
            type: 'post',
            url: '/Admin/Update',
            dataType: 'json',
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",
            success: function (response) {

                if (response.statusCode == 200) {
                    bootbox.alert("Update successfully!", function () {
                        $('#modal-add').modal('hide')
                        location.reload()
                    })
                }
                else if (response.statusCode == 400) {
                    bootbox.alert("404")
                }
                else {
                    bootbox.alert("Update Error!")
                }
            }
        })
        $('#modal-add').modal('hide');
    }
}
