module panoptic.teams.development
{
    export interface IBurnDownEntry
    {
        Time: number;
        Count: number;
    }

    export interface IBurnDownInformation
    {
        Name: string;
        BurnDown: Array<IBurnDownEntry>;
    }

    export interface IBurnDownEntryView
    {
        x: number;
        y: number;
    }

    export interface IBurnDownGraph
    {
        label: string;
        values: Array<IBurnDownEntryView>
    }
}