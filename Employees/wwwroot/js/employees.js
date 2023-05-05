
$(document).ready(function () {
    localDataTable();
});

function localDataTable() {
    dataTable = $('#employeeTableData').DataTable(
        {
            "ajax": { url: '/employees/employeeDetails/getall' },
            "columns": [
                { data: 'firstName', "width": "25%" },
                { data: 'lastName', "width": "15%" },
                { data: 'employeeCode', "width": "15%" },
                { data: 'department.departmentName', "width": "15%" },
                {
                    data: 'id',
                    "render": function (data) {
                        return `<div class="w-75 btn-group" role="group">
                            <a href="/employees/employeeDetails/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                            <a onCLick=Delete('/employees/employeeDetails/delete?id=${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</a>
                            </div>`
                    },
                    "width": "30%"
                }
            ]
        });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}