$(document).ready(function () {
    $('body').off('click', '#btn-add').on('click', '#btn-add', Add);
    $('body').off('click', '#btn-delete').on('click', '#btn-delete', ComfirmDelete);
    $('body').off('click', '#btn-recover').on('click', '#btn-recover', Recover);

    LoadSector_partialview();
    LoadSectorNotActive_partialview();
    function LoadSector_partialview() {
        $.ajax({
            type: 'post',
            url: '/sector/GetAll',
            success: function (response) {
                $('#table-active').html(response);
            }
        })
    }
    function LoadSectorNotActive_partialview() {
        $.ajax({
            type: 'post',
            url: '/sector/GetAllNotActive',
            success: function (response) {
                $('#table-not-active').html(response);
            }
        })
    }
    function Add() {
        var _tranferSector = $('#txt-sector').val();
        debugger
        $.ajax({
            type: 'post',
            url: '/Sector/FindSector',
            dataType: 'json',
            data: { sectorName: _tranferSector },
            success: function (response) {
                if (_tranferSector == "") {
                    bootbox.alert('Vui lòng nhập sector')
                }
                else {
                    var data = response.result;
                    if (data == null) {
                        bootbox.alert(`khong tim thay ${_tranferSector}?`)
                        AddSector();
                    }
                    else {
                        bootbox.alert(`${_tranferSector}? đã tồn tại`)
                        $('#sap').text(data.sector);
                    }
                }

            }
        })
    }
    function AddSector() {
        var model = new Object();
        model.Sector = $('#txt-sector').val();
        $.ajax({
            type: 'post',
            url: '/Sector/Add',
            dataType: 'json',
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",

            success: function (response) {
                if (response.statusCode == 200) {
                    bootbox.alert("OK");
                    LoadSector_partialview();
                } else {
                    bootbox.alert("Error")
                }
            }
        })
    }
    function ComfirmDelete() {
        debugger
        var tranferId = $(this).data('id');
        var tranferSector = $(this).data('sector');
        bootbox.confirm(`Are you sure to delete ${tranferSector} ?`, function (result) {
            if (result) {
                Delete(tranferId, tranferSector)
            }
        });
    }
    function Delete(tranferId,  tranferSector) {
        $.ajax({
            type: 'post',
            url: '/sector/Delete',
            dataType: 'json',
            data: { id: tranferId },

            success: function (response) {
                debugger
                var data = response.statusCode;
                if (data == 200) {
                    bootbox.alert(`Delete ${tranferSector} successfully`, function () {
                        location.reload();
                    })
                }
                else {
                    bootbox.alert("Error");
                }
            }
        })
    }
    function Recover() {

        var tranferId = $(this).data('id1');
        var tranferSector = $(this).data('sector1');
        debugger

        $.ajax({
            type: 'post',
            url: '/sector/Recover',
            dataType: 'json',
            data: { id: tranferId },

            success: function (response) {
                var data = response.statusCode;
                if (data == 200) {
                    bootbox.alert(`Recover ${tranferSector} successfully`, function () {
                        location.reload();
                    })
                }
                else {
                    bootbox.alert("Error");
                }
            }
        })
    }
})