module panoptic.teams.platform
{
    export interface IServiceInformation
    {
        Name: string;
        Status: string;
        Machines: Array<panoptic.teams.platform.IMachineStatusInformation>;
    }

    export interface IEnvironmentInformation
    {
        Name: string;
        Description: string;
        Services: Array<panoptic.teams.platform.IServiceInformation>;
    }
}