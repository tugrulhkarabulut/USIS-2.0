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
                    $('#takeCourseAlert').addClass('alert-success');
                    $('#takeCourseAlert').text('You took the course!');

                    var currentCapacity = Number($('#currentCapacity').text());
                    $('#currentCapacity').text(currentCapacity + 1);
                } else {
                    $('#takeCourseAlert').addClass('alert-danger');
                    $('#takeCourseAlert').text('You already took the course before!');
                }

                setTimeout(() => {
                    $('#takeCourseAlert').hide();
                }, 3000);
            },
            error: function () {
                $('#takeCourseAlert').show();
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