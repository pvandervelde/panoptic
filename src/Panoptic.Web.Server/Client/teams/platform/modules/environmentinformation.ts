module panoptic.teams.platform
{
    export interface IServiceInformation
    {
        Name: string;
        Status: string;
    }

    export interface IEnvironmentInformation
    {
        Name: string;
        Services: Array<panoptic.teams.platform.IServiceInformation>;
    }
}