(function () {
    $('#takeCourseAlert').hide();

    $('.takeCourseBtn').click(function (event) {
        event.preventDefault();

        var data = {
            studentID: event.target.dataset.studentid,
            openedCourseID: event.target.dataset.openedcourseid
        };

        $.ajax({
            type: "post",
            url: "/CourseRegistrations/Create",
            data,
            success: function (res) {
                $('#takeCourseAlert').show();
                if (res.created) {
                    $('#takeCourseAlert').removeClass('alert-danger');
                    $('#takeCourseAlert').addClass('alert-success');

                    var currentCapacityEl = $('#openedCourse-' + data.openedCourseID + ' #currentCapacity');
                    var currentCapacity = Number(currentCapacityEl.text());
                    currentCapacityEl.text(currentCapacity + 1);
                } else {
                    $('#takeCourseAlert').removeClass('alert-success');
                    $('#takeCourseAlert').addClass('alert-danger');
                }

                $('#takeCourseAlert').text(res.message);

                setTimeout(() => {
                    $('#takeCourseAlert').hide();
                }, 3000);
            },
            error: function () {
                $('#takeCourseAlert').show();
                $('#takeCourseAlert').removeClass('alert-success');
                $('#takeCourseAlert').addClass('alert-danger');
                $('#takeCourseAlert').text('An error occurred!');

                setTimeout(() => {
                    $('#takeCourseAlert').hide();
                }, 3000);
            }
         }
        );
    })
})();