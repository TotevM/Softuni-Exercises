function manageMovies(commands) {
    let movies = [];

    for (let command of commands) {
        if (command.startsWith('addMovie')) {
            let movieName = command.replace('addMovie ', '');
            movies.push({ name: movieName });
        } else if (command.includes('directedBy')) {
            let [name, director] = command.split(' directedBy ');
            let movie = movies.find((m) => m.name === name);

            if (movie) {
                movie.director = director;
            }
        } else if (command.includes('onDate')) {
            let [name, date] = command.split(' onDate ');
            let movie = movies.find((m) => m.name === name);

            if (movie) {
                movie.date = date;
            }
        }
    }

    let completeMovies = movies.filter((m) => m.name && m.director && m.date);

    completeMovies.forEach((movie) => console.log(JSON.stringify(movie)));
}