import axios from 'axios'
import { apiUrl } from '../../app-config.json'

export const baseURL = apiUrl

axios.defaults.baseURL = baseURL
axios.defaults.headers.get.Accept = 'application/json' // default header for all get request
axios.defaults.headers.post.Accept = 'application/json' // default header for all POST request

export enum Path {
  Subject = `subject`,
}

export const post = <T>(path: Path, data: T) =>
  axios.post(path, {
    date: new Date().toISOString(),
    [path]: data,
  })

// export const get = <T>(path:Path)
