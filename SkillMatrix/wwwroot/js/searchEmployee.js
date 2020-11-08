$(document).ready(function () {
    $('body').off('click', '#btn-search').on('click', '#btn-search', Search);

    function Search() {
        var _tranferSAP = $('#txt-SAP').val();
       
        $.ajax({
            type: 'post',
            url: '/admin/GetBySAP',
            dataType: 'json',
            data: { sap: _tranferSAP },
            success: function (response) {
                if (_tranferSAP == "") {
                    bootbox.alert('Vui lòng nhập SAP')
                }
                else {
                    var data = response.result;
                     
                    if (data == null) {
                        bootbox.alert(`khong tim thay ${_tranferSAP}?`)
                    }
                    else {
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
                        $('#totalAssesment').text(data.totalAssesment);
                    }
                }
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