function getArmyInfo(input) {
    const leaders = new Map();

    for (const entry of input) {
        if (entry.endsWith('arrives')) {
            const leader = entry.split(' ')[0];
            leaders.set(leader, { totalArmy: 0, armies: {} });
        } else if (entry.includes(':')) {
            const [leader, data] = entry.split(': ');
            if (leaders.has(leader)) {
                const [armyName, armyCount] = data.split(', ');
                const count = Number(armyCount);

                const leaderInfo = leaders.get(leader);
                leaderInfo.armies[armyName] =
                    (leaderInfo.armies[armyName] || 0) + count;
                leaderInfo.totalArmy += count;
            }
        } else if (entry.includes('+')) {
            const [armyName, armyCount] = entry.split(' + ');
            const count = Number(armyCount);

            for (const data of leaders.values()) {
                if (data.armies[armyName]) {
                    data.armies[armyName] += count;
                    data.totalArmy += count;
                }
            }
        } else if (entry.endsWith('defeated')) {
            const leader = entry.split(' ')[0];
            leaders.delete(leader);
        }
    }

    [...leaders.entries()]
        .sort((a, b) => b[1].totalArmy - a[1].totalArmy)
        .forEach(([leader, data]) => {
            console.log(`${leader}: ${data.totalArmy}`);
            Object.entries(data.armies)
                .sort((a, b) => b[1] - a[1])
                .forEach(([armyName, armyCount]) =>
                    console.log(`>>> ${armyName} - ${armyCount}`)
                );
        });
}
