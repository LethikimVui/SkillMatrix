$(document).ready(function () {



    var homeconfig = {
        pageSize: 3,
        pageIndex: 1
    }

    var EmployeeTable =
    {

        loadData: function (changePageSize) {
            debugger
            var totalBlog = 0;

            var model = new Object(); 
            model.PageSize = homeconfig.pageSize
            model.PageIndex = homeconfig.pageIndex - 1;


            $.ajax({
                type: 'post',
                url: '/admin/Count',
                dataType: 'json',
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    totalBlog = parseInt(data.result);

                }
            });
            $.ajax({
                type: 'post',
                url: '/admin/Pagination_PartialView',
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

    EmployeeTable.loadData();



})