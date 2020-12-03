
$(document).ready(function () {
    $('body').off('click', '#btn-search').on('click', '#btn-search', Search);
    $('body').off('click', '#evaluate').on('click', '#evaluate', LoadEmployeeInfo);

    function Search() {
        var _tranferSAP = $('#txt-search').val();
        $.ajax({
            type: 'post',
            url: '/admin/GetEmployeeBySAP',
            dataType: 'json',
            data: { sap: _tranferSAP },
            success: function (response) {
                if (_tranferSAP == "") {
                    bootbox.alert('Vui lòng nhập SAP')
                }
                else {
                    var data = response.result;
                    if (data == []) {
                        bootbox.alert(`khong tim thay ${_tranferSAP}?`)
                    }
                    else {
                        LoadEmployees(_tranferSAP)
                    }
                }
            }
        })
    }
    function LoadEmployees(_tranferSAP) {
        $.ajax({
            type: 'post',
            url: '/admin/GetEmployeeBySAP_partialView',
            data: { sap: _tranferSAP },
            success: function (response) {
                $('#table-employees').html(response);
            }
        })
    }
    function LoadEmployeeInfo() {
        var _tranferSAP = $(this).data('sap'); //$('#txt-search').val();
        
        $.ajax({
            type: 'post',
            url: '/admin/GetBySAP',
            dataType: 'json',
            data: { sap: _tranferSAP },
            success: function (response) {
                var data = response.result;

                        LoadSkill(_tranferSAP)
                        $('#sap').text(data.sap);
                        $('#name').text(data.name);
                        $('#email').text(data.email);
                        $('#superiorEmail').text(data.superiorEmail);
                        $('#workcell').text(data.workcell);
                        $('#position').text(data.position);
                        $('#sector').text(data.sector);
                        $('#image').attr("src", '/images/' + data.image);
                        $('#totalWeight').text(data.totalWeight);
            
            }
        })
    }

    function LoadSkill(_tranferSAP) {
        $.ajax({
            type: 'post',
            url: '/admin/GetSkillMatrix',
            data: { sap: _tranferSAP },
            success: function (response) {
                $('#table-matrix').html(response);
            }
        })
    }
})