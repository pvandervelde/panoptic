module panoptic.teams.platform
{
    export interface IReleaseInformation
    {
        Name: string;
        Version: string;
        ReleaseDate: Date;
        DeployDate: Date;
    }
}