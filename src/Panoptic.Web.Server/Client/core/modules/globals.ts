module panoptic.core.modules
{
    export interface IGlobalsProvider extends ng.IServiceProvider
    {
        $get: () => IGlobalVariables;
    }

    export interface IGlobalVariables
    {
        baseUrl: string;
        webApiBaseUrl: string;
        version: string;
    }
}