export type TApiClientOptions = {
    url: string,
    method?: string,
    body?: any,
}

export type TApiClientError = {
    message: string,
}

export type TApiClientResponse<T> = T & {
    data: T,
    error?: TApiClientError,
}

export class BaseApiClient {

    public baseUrl : string;

    constructor(baseUrl : string) {
        this.baseUrl = baseUrl;
    }

    public async get<T>(url : string) : Promise<TApiClientResponse<T>> {
        return this._handleRequest({ url });
    }

    public async post<T>(url : string, body : any) : Promise<TApiClientResponse<T>> {
        return this._handleRequest({ url, method: "POST", body });
    }

    public async put<T>(url : string, body : any) : Promise<TApiClientResponse<T>> {
        return this._handleRequest({ url, method: "PUT", body });
    }

    public async delete<T>(url : string) : Promise<TApiClientResponse<T>> {
        return this._handleRequest({ url, method: "DELETE" });
    }

    private async _handleRequest<T>(options : TApiClientOptions) : Promise<TApiClientResponse<T>> {
        let requestBody = null;
        if(options.body) {
            requestBody = this._objectToFormData(options.body, null, []);
        }
        
        let authToken = null
        if(window?.localStorage) {
            authToken = window.localStorage.getItem("authToken");
        }

        const fetchOptions : RequestInit = {
            method : options.method ?? "GET",
            body : requestBody,
            headers : {
                "Authorization" : `Bearer ${authToken}`,
            }
        }

        const url = `${this.baseUrl}${options.url}`;

        const response = await fetch(url, fetchOptions);
        const json = await response.json() as TApiClientResponse<T>;

        if(json?.error) {
            throw new Error(json.error.message);
        }
        else if (response.status >= 400) {
            throw new Error(response.statusText)
        }

        return json;
    }


    // Converts any object to a FormData object
    private _objectToFormData(obj : any, rootName : any, ignoreList : any) : FormData {
        var formData = new FormData();
    
        function appendFormData(data : any, root : any) {
            if (!ignore(root)) {
                root = root || '';
                if (data instanceof File) {
                    formData.append(root, data);
                } else if (Array.isArray(data)) {
                    for (var i = 0; i < data.length; i++) {
                        appendFormData(data[i], root + '[' + i + ']');
                    }
                } else if (typeof data === 'object' && data) {
                    for (var key in data) {
                        if (data.hasOwnProperty(key)) {
                            if (root === '') {
                                appendFormData(data[key], key);
                            } else {
                                appendFormData(data[key], root + '.' + key);
                            }
                        }
                    }
                } else {
                    if (data !== null && typeof data !== 'undefined') {
                        formData.append(root, data);
                    }
                }
            }
        }
    
        function ignore(root : any){
            return Array.isArray(ignoreList)
                && ignoreList.some(function(x) { return x === root; });
        }
    
        appendFormData(obj, rootName);
    
        return formData;
    }
    

}