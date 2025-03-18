function solve(arr = []) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    const n = arr[0];
    const songs = [];

    for (let i = 1; i <= n; i++) {
        const [typeList, name, time] = arr[i].split('_');
        songs.push(new Song(typeList, name, time));
    }

    const filterType = arr[arr.length - 1];

    songs.forEach((song) => {
        if (filterType === 'all' || song.typeList === filterType) {
            console.log(song.name);
        }
    });
}
