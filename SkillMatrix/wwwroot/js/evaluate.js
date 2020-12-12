$(document).ready(function () {
    //$('body').off('click', '.update').on('click', '.update', Update);
    $('body').off('click', '#btn-save').on('click', '#btn-save', Save);


    function Update() {

        var _tranferSAP = $(this).data('sap');
        debugger
        $.ajax({
            type: 'post',
            url: '/Employee/GetById',
            dataType: 'json',
            data: { id: tranferId }, /*id la input cua ham /Employee/GetById*/
            success: function (response) {


                var data = response.result;


                $('#txt-ID').val(data.id);
                $('#txt-FullName').val(data.fullName);
                $('#txt-Department').val(data.department);
                $('#txt-Image').val(data.image);
                $('#txt-Email').val(data.email);

            }
        })

    }

    function Save() {
        if ($('#frm-save').valid()) {
            var model = new Object();
            debugger
            model.Id = $('#txt-ID').val();
            model.Sap = $('#txt-FullName').val();
            model.Topic = $('#txt-Department').val();
            model.EvalScore = $('#txt-Image').val();
            model.AssesScore = $('#txt-EvalScore').val();


            $.ajax({
                type: 'post',
                url: '/admin/UpdateScore',
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


    function ComfirmDelete() {
        debugger
        var tranferId = $(this).data('username');
        bootbox.confirm(`Are you sure to delete ${tranferId}?`, function (result) {
            if (result) {
                Delete(tranferId)
            }
        });

    }

    function Delete(tranferId) {

        $.ajax({
            type: 'post',
            url: '/Employee/Delete',
            dataType: 'json',
            data: { id: tranferId },

            success: function (response) {
                debugger
                var data = response.statusCode;
                if (data == 200) {
                    bootbox.alert(`Delete ${tranferId} successfully`, function () {
                        location.reload();
                    })
                }
                else {
                    bootbox.alert("Error");
                }

            }
        })
    }

    //$('#frm-save').validate({
    //    rules: {
    //        ID:
    //        {
    //            required: true,
    //        },
    //        FullName:
    //        {
    //            required: true,
    //        },
    //        Department:
    //        {
    //            required: true,
    //        },
    //        Image:
    //        {
    //            required: true,
    //        },
    //        Email:
    //        {
    //            required: true,
    //        },

    //    },
    //    messages: {

    //        ID:
    //        {
    //            required: "Bạn phải nhập trường này",
    //        },
    //        FullName:
    //        {
    //            required: "Bạn phải nhập trường này",
    //        },
    //        Department:
    //        {
    //            required: "Bạn phải nhập trường này",
    //        },
    //        Image:
    //        {
    //            required: "Bạn phải nhập trường này",
    //        },
    //        Email:
    //        {
    //            required: "Email is required",
    //            required: "not email format",
    //        },
    //    }
    //});


})