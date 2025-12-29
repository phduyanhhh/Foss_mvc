(function ($) {
    var _employeeService = abp.services.app.employeeAppServices,
        l = abp.localization.getSource("Foss"),
        _$modal = $("#EmployeeCreateModal"),
        _$form = _$modal.find("form"),
        _$table = $("#EmployeesTable");

    var _$employeesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        processing: true,
        listAction: {
            ajaxFunction: _employeeService.getList,
            inputFilter: function () {
                return $("#EmployeesSearchForm").serializeFormToObject(true);
            },
        },
        buttons: [
            {
                name: "refresh",
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$employeesTable.draw(false),
            },
        ],
        responsive: {
            details: {
                type: "column",
            },
        },
        columnDefs: [
            {
                targets: 0,
                className: "control",
                defaultContent: "",
                orderable: false,
            },
            {
                targets: 1,
                data: "firstName",
            },
            {
                targets: 2,
                data: "lastName",
            },
            {
                targets: 3,
                data: "email",
            },
            {
                targets: 4,
                data: "phoneNumber",
            },
            {
                targets: 5,
                data: "address",
            },
            {
                targets: 6,
                data: "salary",
                render: (data, type, row, meta) => {
                    return row.salary.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
                }
            },
            {   
                targets: 7,
                data: 'stringIsPosition',
                render: (data, type, row, meta) => {
                    return `<span class="badge ?"> ${l(data)}</span>`;
                }
            },
            {
                targets: 8,
                data: "dateOfBirth",
            },
            {
                targets: 9,
                data: 'stringIsGender',
                render: (data, type, row, meta) => {
                    return `<span class="badge badge-primary"> ${l(data)}</span>`;
                }
            },
            {
                targets: 10,
                data: null,
                orderable: false,
                autoWidth: false,
                defaultContent: "",
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-employee" data-employee-id="${row.id}" data-bs-toggle="modal" data-bs-target="#EmployeeEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l("Edit")}`,
                        "   </button>",
                        `   <button type="button" class="btn btn-sm bg-danger delete-employee" data-employee-id="${row.id}" data-employee-name="${row.firstName}">`,
                        `       <i class="fas fa-trash"></i> ${l("Delete")}`,
                        "   </button>",
                    ].join("");
                },
            },
        ],
    });

    _$modal
        .on("shown.bs.modal", () => {
            _$modal.find("input:not([type=hidden]):first").focus();
        })
        .on("hidden.bs.modal", () => {
            _$form.clearForm();
        });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        //alert("xxx");
        if (!_$form.valid()) {
            return;
        }

        var data = {
            FirstName: $("#firstName").val(),
            LastName: $("#lastName").val(),
            Email: $("#email").val(),
            PhoneNumber: $("#phoneNumber").val(),
            Address: $("#address").val(),
            Gender: $('input[name="gender"]:checked').val(),
            Position: $('input[name="position"]:checked').val(),
            DateOfBirth: $("#dateOfBirth").val(),
            Salary: $("#salary").val(),
        };

        $.ajax({
            url: '/api/services/app/EmployeeAppServices/Create',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function(response) {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                location.href = '/Employees';
            },
            error: function(err) {
                console.error("Lỗi", err);
            }
        });


    });
    
    $(document).on("click", ".edit-employee", function (e) {
        var employeeId = $(this).attr("data-employee-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + "Employees/EditModal?employeeId=" + employeeId,
            type: "POST",
            dataType: "html",
            success: function (content) {
                $("#EmployeeEditModal div.modal-content").html(content);
            },
            error: function (e) {},
        });
    });

    
    //delete
    $(document).on('click', '.delete-employee', function () {
        var employeeId = $(this).attr("data-employee-id");
        var employeeName = $(this).attr('data-employee-name');

        deleteEmployee(employeeId, employeeName);
    });
    function deleteEmployee(employeeId, employeeName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                employeeName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _employeeService.deleteEmployee(
                        employeeId
                    ).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$employeesTable.ajax.reload();
                    });
                }
            }
        );
    }

})(jQuery);
