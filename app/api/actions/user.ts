import { Path, postByBody, postByScheme } from '../axios'
import { v4 as uuidv4 } from 'uuid'
import { customPost } from '../../actions/common/common'

export interface UserAuthorizeData {
  loginName: string
  password: string
}

export const authorizeUser = async (userData: UserAuthorizeData) =>
  await postByBody<UserAuthorizeData>(`${Path.User}/authenticate`, userData)

interface RegisterUserProps {
  userKey: string
}

export interface RegisterUserFormData {
  firstName: string
  lastName: string
  loginName: string
  password: string
  emailAddress: string
  semesterValue: number
}

type RegisterUserPost = RegisterUserProps & RegisterUserFormData
export const postRegisterUser = async (data: RegisterUserFormData) =>
  await postByScheme<RegisterUserPost, AuthenticateUserPostResponse>(
    Path.User,
    {
      ...data,
      userKey: uuidv4(),
    },
  )

export interface AuthenticateUserFormData {
  loginName: string
  password: string
}

type AuthenticateUserPost = AuthenticateUserFormData

interface AuthenticateUserPostResponse {
  token: string
  userKey: string
  firstName: string
  lastName: string
  loginName: string
}

export const postAuthenticateUser = async (data: AuthenticateUserFormData) =>
  await customPost<AuthenticateUserPost, AuthenticateUserPostResponse>(
    Path.User + '/authenticate',
    data,
  )
