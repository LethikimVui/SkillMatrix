
$(document).ready(function () {
    $('body').off('click', '#btn-search').on('click', '#btn-search', Search);
    $('body').off('click', '#evaluate').on('click', '#evaluate', LoadEmployeeInfo);
    function Search() {
        EmployeeTable.loadData();

    }
    function Search2() {
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
                        LoadEmployees(_tranferSAP);
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

    var homeconfig = {
        pageSize: 2,
        pageIndex: 1
    }

    var EmployeeTable =
    {
        loadData: function (changePageSize) {
            var _tranferSAP = $('#txt-search').val(); //$(this).data('search');
            var totalBlog = 0;
            var model = new Object();
            model.PageSize = homeconfig.pageSize
            model.PageIndex = homeconfig.pageIndex - 1;
            model.Input = _tranferSAP;

            debugger

            $.ajax({
                type: 'post',
                url: '/admin/CountEmployeeWithCondition',
                dataType: 'json',
                data: { input: _tranferSAP },
                success: function (data) {
                    totalBlog = parseInt(data.result);
                }
            });
            $.ajax({
                type: 'post',
                url: '/admin/GetPaginationWithCondition',
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $("#table-content").html(data);
                    EmployeeTable.paging(totalBlog, function () {
                    }, changePageSize);
                }
            });
        },
        paging: function (totalRow, callback, changePageSize) {

            var totalPage = 0;
            if (totalRow < homeconfig.pageSize) {
                totalPage = 1
            }
            else {
                totalPage = Math.ceil(totalRow / homeconfig.pageSize);
            }
            if ($('#pagination a').length === 0 || changePageSize === true) {
                $('#pagination').empty();
                $('#pagination').removeData("twbs-pagination");
                $('#pagination').unbind("page");
            }
            $('#pagination').twbsPagination({
                totalPages: totalPage,
                first: "<<",
                next: ">",
                last: ">>",
                prev: "<",
                visiblePages: 10,
                onPageClick: function (event, page) {

                    homeconfig.pageIndex = page;
                    EmployeeTable.loadData();

                }
            });
        },
    }
})