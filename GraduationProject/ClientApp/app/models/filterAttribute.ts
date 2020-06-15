export class filterAttribute{
    titleNames: string[];
    staticChoices: string[];
    dynamicChoices: string[];
}

export class filter{
    TitleName: string[]; 
    FilterType: string[];
    choices: dictionary[];
}

export class dictionary{
    choice: string;
    value: any[];
}