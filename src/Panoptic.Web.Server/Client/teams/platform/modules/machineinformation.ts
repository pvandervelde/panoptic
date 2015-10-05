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
        Name: string;
        Status: string;
    }

    export interface ICpuLoad
    {
        Time: number;
        Load: number;
    }

    export interface IMachineStatisticsInformation extends IMachineStatusInformation
    {
        CurrentCpu: number;
        CpuHistory: Array<panoptic.teams.platform.ICpuLoad>;
        MemoryInUseInMb: number;
        TotalMemoryInMb: number;
        Storage: Array<panoptic.teams.platform.IStorageInformation>
    }

    export interface ICpuLoadView
    {
        x: any;
        y: any;
    }

    export interface ICpuGraphView
    {
        label: string;
        values: Array<ICpuLoadView>;
    }

    export interface IMachineStatisticsViewInformation extends IMachineStatisticsInformation
    {
        CpuGraph: ICpuGraphView;
    }
}