function extract(parentId) {
    const element = document.getElementById(parentId);
    const matches = element.textContent.match(/\(([^)]+)\)/g) || [];

    return matches.map(match => match.slice(1, -1)).join('; ');
}
