(function ($) {
    var _employeeService = abp.services.app.employeeAppServices,
        l = abp.localization.getSource("Foss"),
        _$modal = $("#EmployeeEditModal"),
        _$form = _$modal.find("form");

    function save() {
        if (!_$form.valid()) {
            return;
        }

        // Lấy dữ liệu form thành object
        var employee = _$form.serializeFormToObject();

        // Lấy giá trị radio Gender
        var genderRadio = _$form.find("input[name='gender']:checked");
        if (genderRadio.length) {
            employee.Gender = genderRadio.val();
        }

        // Lấy giá trị radio Position
        var positionRadio = _$form.find("input[name='Position']:checked");
        if (positionRadio.length) {
            employee.Position = positionRadio.val();
        }

        abp.ui.setBusy(_$form);
        _employeeService
            .updateEmployee(employee) // hoặc .create(employee) nếu modal tạo mới
            .done(function () {
                _$modal.modal("hide");
                abp.notify.info(l("SavedSuccessfully"));
                abp.event.trigger("employee.edited", employee);
                location.href = '/Employees';
            })
            .always(function () {
                abp.ui.clearBusy(_$form);
            });
    }

    // Bắt sự kiện click nút save trong modal footer
    _$form
        .closest("div.modal-content")
        .find(".save-button")
        .click(function (e) {
            e.preventDefault();
            save();
        });

    // Bắt sự kiện nhấn Enter
    _$form.find("input").on("keypress", function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    // Focus input đầu tiên khi modal hiện
    _$modal.on("shown.bs.modal", function () {
        _$form.find("input[type=text]:first").focus();
    });
})(jQuery);
