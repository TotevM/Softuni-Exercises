function guildManagement(input) {
    const lines = input;
    const n = parseInt(lines[0]);

    const guildMembers = {};
    for (let i = 1; i <= n; i++) {
        const parts = lines[i].split(' ');
        const name = parts[0];
        const role = parts[1];
        const skills = parts[2].split(',');
        guildMembers[name] = { role, skills };
    }

    let commandIndex = n + 1;
    const results = [];

    while (lines[commandIndex] !== 'End') {
        const commands = lines[commandIndex].split(' / ');
        const action = commands[0];

        if (action === 'Perform') {
            const [_, memberName, role, skill] = commands;

            if (
                guildMembers[memberName].role === role &&
                guildMembers[memberName].skills.includes(skill)
            ) {
                results.push(
                    `${memberName} has successfully performed the skill: ${skill}!`
                );
            } else {
                results.push(
                    `${memberName} cannot perform the skill: ${skill}.`
                );
            }
        } else if (action === 'Reassign') {
            const [_, memberName, newRole] = commands;
            guildMembers[memberName].role = newRole;
            results.push(`${memberName} has been reassigned to: ${newRole}`);
        } else if (action === 'Learn Skill') {
            const [_, memberName, newSkill] = commands;

            if (guildMembers[memberName].skills.includes(newSkill)) {
                results.push(
                    `${memberName} already knows the skill: ${newSkill}.`
                );
            } else {
                guildMembers[memberName].skills.push(newSkill);
                results.push(
                    `${memberName} has learned a new skill: ${newSkill}.`
                );
            }
        }

        commandIndex++;
    }

    for (const memberName in guildMembers) {
        const member = guildMembers[memberName];
        const sortedSkills = [...member.skills].sort();
        results.push(
            `Guild Member: ${memberName}, Role: ${
                member.role
            }, Skills: ${sortedSkills.join(', ')}`
        );
    }

    return results.join('\n');
}
