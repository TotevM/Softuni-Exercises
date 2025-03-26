function browseTheWeb(browser, commands) {
    const openTabs = browser['Open Tabs'];
    const recentlyClosed = browser['Recently Closed'];
    const browserLogs = browser['Browser Logs'];

    for (const command of commands) {
        if (command === 'Clear History and Cache') {
            openTabs.length = 0;
            recentlyClosed.length = 0;
            browserLogs.length = 0;
            continue;
        }

        const [action, site] = command.split(' ');

        if (action === 'Open') {
            openTabs.push(site);
            browserLogs.push(`Open ${site}`);
        } else if (action === 'Close') {
            const tabIndex = openTabs.indexOf(site);
            if (tabIndex !== -1) {
                recentlyClosed.push(openTabs.splice(tabIndex, 1)[0]);
                browserLogs.push(`Close ${site}`);
            }
        }
    }

    console.log(
        `${browser['Browser Name']}\n` +
            `Open Tabs: ${openTabs.join(', ')}\n` +
            `Recently Closed: ${recentlyClosed.join(', ')}\n` +
            `Browser Logs: ${browserLogs.join(', ')}`
    );
}
