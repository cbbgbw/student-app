import axios, { AxiosResponse } from 'axios'

export const baseURL = 'https://localhost:44310/api'

axios.defaults.baseURL = baseURL
axios.defaults.headers.get.Accept = 'application/json' // default header for all get request
axios.defaults.headers.post.Accept = 'application/json' // default header for all POST request

interface PostRequest<T> {
  date: string
  dataObject: T
}

export enum Path {
  Subject = `subject`,
}

export const post = <T>(path: Path, data: T): AxiosResponse =>
  axios.post<PostRequest<T>>(path, {
    date: new Date().toISOString(),
    [path]: data,
  })

// export const get = <T>(path:Path)
