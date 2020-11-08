$(document).ready(function () {

    function Update() {

    var tranferSAP = $(this).data('sap');
    $.ajax({
        type: 'post',
        url: '/Admin/GetSkillMatrix',
        dataType: 'json',
        data: { sap: tranferSAP },

        success: function (response) {


            var data = response.result;


        })
})