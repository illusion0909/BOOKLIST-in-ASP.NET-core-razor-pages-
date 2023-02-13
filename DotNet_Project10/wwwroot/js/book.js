var dataTable;
$(document).ready(function () {
    loaddatatable();
})

function loaddatatable() {
    dataTable = $('#tbldata').DataTable({
        "ajax": {
            "url": "api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "title", "width": "25%" },
            { "data": "author", "width": "25%" },
            { "data": "isbn", "width": "25%" },
            { "data": "price", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
        <div class="text-center">
          <a class="btn btn-info" href="/booklist/upsert/?id=${data}">Edit</a>
          <a class="btn btn-danger" onclick=Delete("api/book?id=${data}")>Delete</a>
          </div>`;

                }
            }
        ]
    })
}
function Delete(url) {
    swal({
        title: "Want TO DELETE DATA ?",
        text: "Delete information!!",
        buttons: true,
        icon: "warning",
        dangerModel: true
    }).then((willdelete) => {
        if (willdelete) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();

                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }

    })
}