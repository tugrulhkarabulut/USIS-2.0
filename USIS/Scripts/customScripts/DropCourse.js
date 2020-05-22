(function () {
    $('#dropCourseAlert').hide();

    $('.dropCourseBtn').click(function (event) {
        var data = {
            courseRegistrationID: event.target.dataset.courseregistrationid
        };

        $.ajax({
            type: "post",
            url: "/CourseRegistrations/Delete",
            data,
            success: function (res) {
                $('#dropCourseAlert').show();
                if (res.deleted) {
                    $('#dropCourseAlert').removeClass('alert-danger');
                    $('#dropCourseAlert').addClass('alert-success');

                    $('#registration-' + data.courseRegistrationID).remove();
                } else {
                    $('#dropCourseAlert').removeClass('alert-success');
                    $('#dropCourseAlert').addClass('alert-danger');
                }

                $('#dropCourseAlert').text(res.message);

                setTimeout(() => {
                    $('#dropCourseAlert').hide();
                }, 3000);
            },
            error: function () {
                $('#dropCourseAlert').show();
                $('#dropCourseAlert').removeClass('alert-success');
                $('#dropCourseAlert').addClass('alert-danger');
                $('#dropCourseAlert').text('An error occurred!');

                setTimeout(() => {
                    $('#dropCourseAlert').hide();
                }, 3000);
            }
        }
        );
    })
})();