function storeBooks(input) {
    const shelves = {};

    for (const entry of input) {
        if (entry.includes('->')) {
            const [id, genre] = entry.split(' -> ');

            if (!shelves[id]) {
                shelves[id] = {
                    genre,
                    books: [],
                };
            }
        } else if (entry.includes(':')) {
            const [title, authorPart] = entry.split(': ');
            const [author, genre] = authorPart.split(', ');

            for (const shelf of Object.values(shelves)) {
                if (shelf.genre === genre) {
                    shelf.books.push({ title, author });
                }
            }
        }
    }

    const sortedShelves = Object.entries(shelves).sort(
        (a, b) => b[1].books.length - a[1].books.length
    );

    for (const [id, shelf] of sortedShelves) {
        console.log(`${id} ${shelf.genre}: ${shelf.books.length}`);

        shelf.books.sort((a, b) => a.title.localeCompare(b.title));

        for (const { title, author } of shelf.books) {
            console.log(`--> ${title}: ${author}`);
        }
    }
}
