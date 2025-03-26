function arrangeStudents(input) {
    const students = {};

    for (const entry of input) {
        const [name, grade, score] = entry
            .split(', ')
            .map((e) => e.split(': ')[1]);

        const numericGrade = Number(grade);
        const numericScore = Number(score);

        if (numericScore > 3) {
            const nextGrade = numericGrade + 1;
            students[nextGrade] = students[nextGrade] || [];
            students[nextGrade].push({ name, score: numericScore });
        }
    }

    Object.entries(students)
        .sort(([a], [b]) => a - b)
        .forEach(([grade, currentStudents]) => {
            const names = currentStudents.map((s) => s.name).join(', ');
            const avgScore = (
                currentStudents.reduce((sum, s) => sum + s.score, 0) /
                currentStudents.length
            ).toFixed(2);

            console.log(`${grade} Grade`);
            console.log(`List of students: ${names}`);
            console.log(`Average annual score from last year: ${avgScore}`);
            console.log();
        });
}
