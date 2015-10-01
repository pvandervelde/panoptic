module panoptic.teams.platform
{
    export interface IStorageInformation
    {
        Name: string;
        CurrentUse: number;
        Size: number;
    }

    export interface IMachineStatusInformation
    {
        Name: string
        status: string;
    }

    export interface IMachineStatisticsInformation extends IMachineStatusInformation
    {
        CurrentCpu: number;
        CpuHistory: Array<number>;
        CurrentMemory: number;
        AvailableMemory: number;
        Storage: Array<panoptic.teams.platform.IStorageInformation>
    }
}