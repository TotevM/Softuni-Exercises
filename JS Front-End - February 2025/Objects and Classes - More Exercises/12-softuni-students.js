function storeStudents(input) {
    const courses = {};

    for (const entry of input) {
        if (entry.includes(':')) {
            const [courseName, capacityString] = entry.split(': ');
            const capacity = Number(capacityString);

            if (!courses[courseName]) {
                courses[courseName] = {
                    capacity,
                    students: [],
                };
            } else {
                courses[courseName].capacity += capacity;
            }
        } else {
            const [userInfo, courseName] = entry.split(' joins ');
            const userMatch = userInfo.match(/^(.+?)\[(\d+)] with email (.+)$/);

            if (userMatch) {
                const [, username, credits, email] = userMatch;
                const creditCount = parseInt(credits, 10);

                if (
                    courses[courseName] &&
                    courses[courseName].students.length <
                        courses[courseName].capacity
                ) {
                    courses[courseName].students.push({
                        username,
                        credits: creditCount,
                        email,
                    });
                }
            }
        }
    }

    const sortedCourses = Object.entries(courses).sort(
        (a, b) => b[1].students.length - a[1].students.length
    );

    for (const [courseName, courseInfo] of sortedCourses) {
        const placesLeft = courseInfo.capacity - courseInfo.students.length;
        console.log(`${courseName}: ${placesLeft} places left`);

        courseInfo.students.sort((a, b) => b.credits - a.credits);

        for (const { username, credits, email } of courseInfo.students) {
            console.log(`--- ${credits}: ${username}, ${email}`);
        }
    }
}
