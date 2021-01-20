import { createContext } from 'react'

export const AuthContext = createContext<{
  mutateSemester: (data: Record<string, string>) => Promise<any>
}>({
  mutateSemester: async () => null,
})
