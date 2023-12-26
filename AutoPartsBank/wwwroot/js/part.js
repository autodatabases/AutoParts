var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url : '/admin/part/getall'},
        "columns": [
            { data: 'partId', "width": "10%" },
            { data: 'partName', "width": "20%" },
            { data: 'description', "width": "35%" },
            { data: 'category.categoryName', "width": "10%" },
            {
                data: 'partId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/part/upsert?partId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>Edit</a>
                        <a onClick=Delete('/admin/part/deletePart?partId=${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i>delete</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url)
{
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    Swal.fire({
                        title: "Deleted!",
                        text: "Your file has been deleted.",
                        icon: "success"
                    });
                }
            })
            
        }
    });
}
