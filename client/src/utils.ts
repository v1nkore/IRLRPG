export function firstLetterToUpperCase(text: string): string {
    return text.charAt(0).toUpperCase() + text.slice(1);
}

export function GetFormStateEmptyTextFields(state: Map<string, string>) {
    let keyValuePairOfEmptyTextFields = new Set<string>();
    for (const [key, value] of Array.from(state.entries())) {
        if (!value || value === '') {
            keyValuePairOfEmptyTextFields.add(key);
        }
    }

    return keyValuePairOfEmptyTextFields;
}

export function ObjectToKeyValues(obj: any) : Map<string, string> {
    let keyValuePairs = new Map<string, string>();
    const keys = Object.keys(obj);
    const values = Object.values(obj);
    for (let i = 0; i < keys.length; i++) {
        keyValuePairs.set(keys.at(i)!, values.at(i) as string);
    }

    return keyValuePairs;
}