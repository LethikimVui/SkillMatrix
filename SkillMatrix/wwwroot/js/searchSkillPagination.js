
$(document).ready(function () {
    $('body').off('click', '#btn-search').on('click', '#btn-search', Search);

    

    function Search() {
        LoadEmployeeInfo();
        SkillMatrixTable.loadData();

    }

    function LoadEmployeeInfo() {
        var _tranferSAP = $(this).data('sap'); //$('#txt-search').val();
        $.ajax({
            type: 'post',
            url: '/admin/GetBySAP',
            dataType: 'json',
            data: { sap: _tranferSAP },
            success: function (response) {
                //LoadSkill1(_tranferSAP)
                SkillMatrixTable.loadData();
                
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
    function LoadSkill() {
        var _tranferSAP = $(this).data('sap');
        debugger
        $.ajax({
            type: 'post',
            url: '/admin/GetSkillMatrix',
            data: { sap: _tranferSAP },
            success: function (response) {
                $('#table-matrix').html(response);
            }
        })
    }

    function LoadSkill1(_tranferSAP) {
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




    var homeconfig_SkillMatrix = {
        pageSize: 2,
        pageIndex: 1
    }

    var SkillMatrixTable =
    {
        loadData: function (changePageSize) {
            //var _tranferSAP = $(this).data('sap');
            var _tranferSAP = $('#txt-search').val();
            var totalBlog = 0;
            var model = new Object();
            model.PageSize = homeconfig_SkillMatrix.pageSize
            model.PageIndex = homeconfig_SkillMatrix.pageIndex - 1;
            model.Input = _tranferSAP;

            debugger

            $.ajax({
                type: 'post',
                url: '/admin/CountSkillMatrix',
                dataType: 'json',
                data: { input: _tranferSAP },
                success: function (data) {
                    totalBlog = parseInt(data.result);
                }
            });
            $.ajax({
                type: 'post',
                url: '/admin/GetSkillPagination',
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $("#table-matrix").html(data);
                    SkillMatrixTable.paging(totalBlog, function () {
                    }, changePageSize);
                }
            });
        },
        paging: function (totalRow, callback, changePageSize) {

            var totalPage = 0;
            if (totalRow < homeconfig_SkillMatrix.pageSize) {
                totalPage = 1
            }
            else {
                totalPage = Math.ceil(totalRow / homeconfig_SkillMatrix.pageSize);
            }
            if ($('#pagination_skill a').length === 0 || changePageSize === true) {
                $('#pagination_skill').empty();
                $('#pagination_skill').removeData("twbs-pagination");
                $('#pagination_skill').unbind("page");
            }
            $('#pagination_skill').twbsPagination({
                totalPages: totalPage,
                first: "<<",
                next: ">",
                last: ">>",
                prev: "<",
                visiblePages: 10,
                onPageClick: function (event, page) {

                    homeconfig_SkillMatrix.pageIndex = page;
                    SkillMatrixTable.loadData();

                }
            });
        },
    }
})