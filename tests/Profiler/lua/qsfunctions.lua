--~ Copyright Ⓒ 2014 Victor Baybekov

package.path = package.path .. ";" .. ".\\?.lua;" .. ".\\?.luac"
package.cpath = package.cpath .. ";" .. '.\\clibs\\?.dll'

local qsfunctions = {}

function qsfunctions.dispatch_and_process(msg)
    if qsfunctions[msg.cmd] then
        -- dispatch a command simply by a table lookup
        -- in qsfunctions method names must match commands
        local status, result = pcall(qsfunctions[msg.cmd], msg)
        if status then
            return result
        else
            msg.cmd = "lua_error"
            msg.lua_error = "Lua error: " .. result
            return msg
        end
    else
        msg.cmd = "lua_error"
        msg.lua_error = "Command not implemented in Lua qsfunctions module: " .. msg.cmd
        return msg
    end
end


------------------------------
-- Debug functions
------------------------------
--- Echoes its message
-- @param msg message table
-- @return same msg table
function qsfunctions.ping(msg)
    -- need to know data structure the caller gives
    msg.t = 0 -- avoid time generation. Could also leave original
    if msg.data == "Ping" then
        msg.data = "Pong"
        return msg
    else
        msg.data = msg.data .. " is not Ping"
        return msg
    end
end

--- Test error handling
function qsfunctions.divide_string_by_zero(msg)
    msg.data = "asd" / 1
    return msg
end

function qsfunctions.is_quik(msg)
    if getScriptPath then msg.data = 1 else msg.data = 0 end
    return msg
end

------------------------------
-- Service functions
------------------------------
--- Функция предназначена для определения состояния подключения клиентского места к
-- серверу. Возвращает «1», если клиентское место подключено и «0», если не подключено.
function qsfunctions.isConnected(msg)
    -- set time when function was called
    msg.t = timemsec()
    msg.data = isConnected()
    return msg
end


--- Функция возвращает путь, по которому находится файл info.exe, исполняющий данный
-- скрипт, без завершающего обратного слэша («\»). Например, C:\QuikFront.
function qsfunctions.getWorkingFolder(msg)
    -- set time when function was called
    msg.t = timemsec()
    msg.data = getWorkingFolder()
    return msg
end

--- Функция возвращает путь, по которому находится запускаемый скрипт, без завершающего
-- обратного слэша («\»). Например, C:\QuikFront\Scripts.
function qsfunctions.getScriptPath(msg)
    -- set time when function was called
    msg.t = timemsec()
    msg.data = getScriptPath()
    return msg
end

--- Функция возвращает значения параметров информационного окна (пункт меню
-- Связь / Информационное окно…).
function qsfunctions.getInfoParam(msg)
    -- set time when function was called
    msg.t = timemsec()
    msg.data = getInfoParam(msg.data)
    return msg
end

--- Функция отображает сообщения в терминале QUIK.
function qsfunctions.message(msg)
    log(msg.data, 1)
    msg.data = ""
    return msg
end
function qsfunctions.warning_message(msg)
    log(msg.data, 2)
    msg.data = ""
    return msg
end
function qsfunctions.error_message(msg)
    log(msg.data, 3)
    msg.data = ""
    return msg
end

--- Функция приостанавливает выполнение скрипта.
function qsfunctions.sleep(msg)
    delay(msg.data)
    msg.data = ""
    return msg
end

--- Функция для вывода отладочной информации. 
function qsfunctions.PrintDbgStr(msg)
    log(msg.data, 0)
    msg.data = ""
    return msg
end


return qsfunctions