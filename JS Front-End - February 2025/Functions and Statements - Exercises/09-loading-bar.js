function load(percentage) {
    if (percentage === 100) {
        console.log(`100% Complete!`);
        console.log(`[${'%'.repeat(10)}]`);
        return;
    }

    const percentCount = percentage / 10;

    console.log(
        `${percentCount * 10}% [${'%'.repeat(percentCount)}${'.'.repeat(
            10 - percentCount
        )}]`
    );
    console.log('Still loading...');
}

load(100);
