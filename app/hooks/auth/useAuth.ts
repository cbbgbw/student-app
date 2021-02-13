import { useContext } from 'react'
import { AuthContext } from '../../components/Auth/Context/Context'

export const useAuth = () => useContext(AuthContext)
