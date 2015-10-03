module panoptic.teams.platform
{
    export interface IStorageInformation
    {
        Name: string;
        StorageInUseInGb: number;
        TotalStorageInGb: number;
    }

    export interface IMachineStatusInformation
    {
        Name: string
        Status: string;
    }

    export interface IMachineStatisticsInformation extends IMachineStatusInformation
    {
        CurrentCpu: number;
        CpuHistory: Array<number>;
        MemoryInUseInMb: number;
        TotalMemoryInMb: number;
        Storage: Array<panoptic.teams.platform.IStorageInformation>
    }
}