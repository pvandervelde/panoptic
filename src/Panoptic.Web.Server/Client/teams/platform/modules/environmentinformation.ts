module panoptic.ops
{
    export interface IServiceInformation
    {
        Name: string;
        Status: string;
    }

    export interface IEnvironmentInformation
    {
        Name: string;
        Services: Array<panoptic.ops.IServiceInformation>;
    }
}