export const parseISOString = (s: string) => {
  const b = s.split(/\D+/)
  // @ts-ignore
  return new Date(Date.UTC(b[0], --b[1], b[2], b[3], b[4], b[5], b[6]))
}

export const getDateFormatted = (deadlineTime: string) => {
  console.log(deadlineTime)
  const date = new Date(deadlineTime)
  const day = date.getUTCDate()
  const month = date.getUTCMonth() + 1
  const hour = date.getUTCHours()
  const minute = date.getUTCMinutes()
  return `${String(day).length === 1 ? 0 : ''}${day}.${
    String(month).length === 1 ? 0 : ''
  }${month} | ${String(hour).length === 1 ? 0 : ''}${hour}:${
    String(minute).length === 1 ? 0 : ''
  }${minute}`
}
