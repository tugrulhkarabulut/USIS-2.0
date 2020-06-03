var app = new Vue({
    el: '#app',
    data: {
        courses: []
    },

    async mounted() {
        document.getElementById('departmentSelectList').addEventListener('change', async event => {
            const departmentID = event.target.value;
            if (departmentID) {
                const response = await fetch('/Courses/ByDepartment/' + departmentID);
                const responseData = await response.json();
                this.courses = responseData.courses;
            }
        });
    },

    methods: {
        calculateTotalCredits(year, semester) {
            return this.courses.filter(c => c.year === year && c.semester == semester).reduce((prev, curr) => prev + curr.credit, 0);
        }
    }
})